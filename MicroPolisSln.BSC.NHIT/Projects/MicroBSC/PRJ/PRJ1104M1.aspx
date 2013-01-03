<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRJ1104M1.aspx.cs" Inherits="PRJ_PRJ1104M1" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>

<html>
<head id="Head1" runat="server">
<title>BSC</title>
<meta http-equiv="Content-Type" content="text/html; " />
<link rel="stylesheet" href="../_common/css/bsc.css" type="text/css" />
<script type="text/javascript" language="javascript" src="../_common/js/common.js"></script>
<script id="Infragistics" type="text/javascript">

    var param1 = false;
    function selectChkBox(chkChild) {
        var _elements = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++) {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type == "checkbox") {
                if (param1) {
                    _elements[i].checked = false;
                }
                else {
                    if (_elements[i].disabled == false)
                        _elements[i].checked = true;
                }
            }
        }
        param1 = (param1 == true) ? false : true;
    }
    
    function openWorkExecForm1(objGrid) {
        var ugrd = document.getElementById(objGrid);
        var gRow = igtbl_getActiveRow(ugrd.id);
        if (gRow.getCellFromKey("WORK_TYPE").getValue() == "C")
            openWorkForm(gRow.getCellFromKey("ESTTERM_REF_ID").getValue(), gRow.getCellFromKey("WORK_DEPT_REF_ID").getValue(), gRow.getCellFromKey("WORK_REF_ID").getValue());
        else
            openExecForm(gRow.getCellFromKey("ESTTERM_REF_ID").getValue(), gRow.getCellFromKey("WORK_DEPT_REF_ID").getValue(), gRow.getCellFromKey("WORK_REF_ID_ORG").getValue(), gRow.getCellFromKey("WORK_REF_ID").getValue());
        return false;
    }
    
    function openWorkExecForm2() {
        var ugrd = document.getElementById('<%= ugrdWorkAll.ClientID %>');
        var gRow = igtbl_getActiveRow(ugrd.id);
        if (gRow.getCellFromKey("WORK_TYPE").getValue() == "C")
            openWorkForm(gRow.getCellFromKey("ESTTERM_REF_ID").getValue(), gRow.getCellFromKey("WORK_DEPT_REF_ID").getValue(), gRow.getCellFromKey("WORK_REF_ID").getValue());
        else
            openExecForm(gRow.getCellFromKey("ESTTERM_REF_ID").getValue(), gRow.getCellFromKey("WORK_DEPT_REF_ID").getValue(), gRow.getCellFromKey("WORK_REF_ID_ORG").getValue(), gRow.getCellFromKey("WORK_REF_ID").getValue());
    }
    
    function openWorkExecForm3() {
        var ugrd = document.getElementById('ugrdWorkList');
        var gRow = igtbl_getActiveRow(ugrd.id);
        if (gRow.getCellFromKey("WORK_TYPE").getValue() == "C")
            openWorkForm(gRow.getCellFromKey("ESTTERM_REF_ID").getValue(), gRow.getCellFromKey("WORK_DEPT_REF_ID").getValue(), gRow.getCellFromKey("WORK_REF_ID").getValue());
        else
            openExecForm(gRow.getCellFromKey("ESTTERM_REF_ID").getValue(), gRow.getCellFromKey("WORK_DEPT_REF_ID").getValue(), gRow.getCellFromKey("WORK_REF_ID_ORG").getValue(), gRow.getCellFromKey("WORK_REF_ID").getValue());
    }
    
    function openWorkForm(estterm_ref_id, est_dept_ref_id, work_ref_id) {
        gfOpenWindow("../PRJ/PRJ1102M1.aspx?iType=U&ESTTERM_REF_ID=" + estterm_ref_id + "&EST_DEPT_REF_ID=" + est_dept_ref_id + "&WORK_REF_ID=" + work_ref_id
                , 720, 630, 'PRJ1102M1');
    }

    function openExecForm(estterm_ref_id, est_dept_ref_id, work_ref_id, exec_ref_id) {
        gfOpenWindow("../PRJ/PRJ1102M5.aspx?iType=U&ESTTERM_REF_ID=" + estterm_ref_id + "&EST_DEPT_REF_ID=" + est_dept_ref_id + "&WORK_REF_ID=" + work_ref_id + "&EXEC_REF_ID=" + exec_ref_id
                , 1000, 820, 'PRJ1102M5');
    }
    
    function alertWorkProc(workID) {
        switch (workID) {
            case "INSERT":
                var ugrd = igtbl_getGridById('<%= ugrdWorkAll.ClientID %>');

                for (var i = 0; i < ugrd.Rows.length; i++) {
                    var tRow = ugrd.Rows.getRow(i);
                    var chkYN = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
                    if (chkYN.checked) {
                        return confirm("선택한 과제를 추가하시겠습니까?");
                    }
                }
                alert("추가할 과제를 먼저 선택하세요.");
                return false;
                break;

            case "DELETE":
                var ugrd = igtbl_getGridById('<%= ugrdWorkPreView.ClientID %>');
                for (var i = 0; i < ugrd.Rows.length; i++) {
                    var tRow = ugrd.Rows.getRow(i);
                    var chkYN = igtbl_getElementById(tRow.getCellFromKey("selchk").Id).children(0);
                    if (chkYN.checked) {
                        return confirm("선택한 과제를 삭제하시겠습니까?");
                    }
                }
                alert("삭제할 과제를 먼저 선택하세요.");
                return false;
                break;
            default:
                return false;
                break;
        }                
    }
    
    function openFullStgMap() {
        var intEstTermID = "<%= this.IESTTERM_REF_ID %>";
        var intEstDeptID = "<%= this.IEST_DEPT_REF_ID %>";
        var intMapVersion = "<%= this.IMAP_VERSION_ID %>";
        var intTermMonth = "<%= this.ITERM_MONTH %>";

        var url = '../usr/usr_stg_map.aspx?ESTTERM_REF_ID=' + intEstTermID + '&EST_DEPT_REF_ID=' + intEstDeptID + '&MAP_VERSION_ID=' + intMapVersion + '&TMCODE=' + intTermMonth + '&LINE_TYPE=0&SHOW_KPI_LIST=1&DRAWING_YN=Y&WORKINGMAPYN=Y';
        var wo  = window.open(url, 'WinPop','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=yes,resizable=0,top=0,left=0,width=screen.width, height=screen.height');
        wo.resizeTo(screen.width,screen.height);
    }
</script>
</head>
<body style="margin:0 0 0 0 ; background-color:#FFFFFF">
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%">
                <tr>
                    <td colspan="2" style="height:40px; vertical-align:top;">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background-image:url(../images/title/popup_t_bg.gif);">
                            <tr> 
                                <td style="height:40px;" valign="top">
                                    <img alt="" src="../images/title/popup_t105.gif" /></td>
                                <td align="right" valign="top" ><img src="../images/title/popup_img.gif" alt="" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style=" height:25px; vertical-align:top; padding-top:1px; padding-bottom:5px; padding-left:2px; padding-right:2px;" colspan="2">
                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
                            <tr>
                                <td align="center" class="tabletitle2" style="width:80px; height:25px;" >선택부서</td>
                                <td class="tableContent" style="border-right: 0px;">
                                    <asp:Label ID="lblEstDeptName" runat="server" Text=""></asp:Label>&nbsp;
                                </td>
                                <td class="tableContent" style="width: 100px; border-left: 0px;" align="right">
                                    <img alt="" onclick="openFullStgMap();" style="cursor:hand;" src="../images/btn/b_216.gif" />&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height:430px; vertical-align:top; padding-top:1px; padding-bottom:5px; padding-left:2px; padding-right:2px;">
                        <!--- Tree  --->	
                        <div id="leftLayer" style="border:#E9EBEB 1 solid; DISPLAY:block; overflow: auto; position:static; 
                            width: 300px;  height: 100%; padding-bottom: 1px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
                            <asp:TreeView ID="trvStgMap" runat="server" PathSeparator=";" OnSelectedNodeChanged="trvStgMap_SelectedNodeChanged" ImageSet="Faq" BorderStyle="None" EnableTheming="False" PopulateNodesFromClient="False" ShowLines="false" NodeIndent="15" >
                                <ParentNodeStyle Font-Bold="False" />
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <SelectedNodeStyle BackColor="#E2ECF4" Font-Underline="False" HorizontalPadding="1px" VerticalPadding="0px" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="1px" NodeSpacing="0px" VerticalPadding="0px" />
                            </asp:TreeView>
                        </div>
                        <sj:smartscroller id="SmartScroller1" runat="server" TargetObject="leftLayer"></sj:smartscroller>
                        <!--- /Tree  --->
                    </td>
                    <td style="height:500px; vertical-align:top; padding-top:1px; padding-bottom:5px; padding-left:2px; padding-right:2px;">
                        <div id="rightLayer" style="border:#E9EBEB 1 solid; DISPLAY:block; overflow: auto; position:static; 
                            width: 690px;  height: 100%; padding-bottom: 2px; padding-left: 2px; padding-right: 2px; padding-top: 2px; ">
                            <asp:Panel ID="pnlDept" runat="server" Visible="true" Height="100%" Width="100%">
                                <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%;">
                                    <tr style="height:25px;">
                                        <td style="width:200px;"><img src="../images/icon/subtitle.gif" alt="" />&nbsp;<b>전략체계도 기본정보</b></td>
                                        <td align="right" style="color: Red;">* 전략체계도 기본정보는 전략체계도 구성화면에서 수정이 가능합니다.&nbsp;&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="width:100%;" valign="top">
                                            <table border="0" cellpadding="0" cellspacing="0" class="tableBorder" style="width:100%; height:100%;">
                                                <tr>
                                                    <td align="center" class="tabletitle2" style="width:100px;">평&nbsp;&nbsp;가&nbsp;&nbsp;기&nbsp;&nbsp;간</td>
                                                    <td class="tableContent" >
                                                        <asp:TextBox ID="txtTermDesc" runat="server" Text="" Width="100%" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="tabletitle2" style="width:100px;" >평&nbsp;가&nbsp;부&nbsp;서&nbsp;명</td>
                                                    <td class="tableContent">
                                                        <asp:TextBox ID="txtEstDeptName" runat="server" Text="" Width="100%" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="tabletitle2" style="width:100px;" >B&nbsp;S&nbsp;C&nbsp;챔&nbsp;피&nbsp;언</td>
                                                    <td class="tableContent">
                                                        <asp:HiddenField ID="hdfBSCChampionID" runat="server" Value="" />
                                                        <asp:TextBox ID="txtBSCChampion" runat="server" Text="" Width="100%" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="tabletitle2" style="width:100px;">조&nbsp;&nbsp;직&nbsp;&nbsp;비&nbsp;&nbsp;젼</td>
                                                    <td class="tableContent" style="height: 200px;">
                                                        <asp:TextBox ID="txtDeptVision" runat="server" TextMode="MultiLine" ReadOnly="true" Height="100%" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="tabletitle2" style="width:100px;" >전&nbsp;략&nbsp;맵&nbsp;버&nbsp;젼</td>
                                                    <td class="tableContent">
                                                        <asp:TextBox ID="txtMapVersionID" runat="server" Text="" Width="16%" ReadOnly="true"></asp:TextBox>
                                                        <asp:TextBox ID="txtMapVersionName" runat="server" Text="" Width="76%" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="tabletitle2" style="width:100px;" >전&nbsp;략&nbsp;맵&nbsp;정&nbsp;보</td>
                                                    <td class="tableContent" style="height: 150px;">
                                                        <asp:TextBox ID="txtMapDesc" runat="server" TextMode="MultiLine" Height="100%" ReadOnly="true" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlSTG" runat="server" Visible="false" Height="100%" Width="100%">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr style="height:30px;">
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td class="tableTitle2">
                                                        <b>전략 별 과제 설정</b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="height:25px;">
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="padding-top: 5px;">
                                                        <img src="../images/icon/subtitle.gif" alt="" />&nbsp;<b>전략별 과제 리스트</b>
                                                    </td>
                                                    <td style="text-align:right; color: Red;">
                                                        (&nbsp;<asp:Label ID="lblWorkListCount" runat="server" ForeColor="Red" Text="중점과제: / 실행과제:"></asp:Label>)&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ig:UltraWebGrid ID="ugrdWorkPreView" runat="server"  Width="100%" Height="182px" OnInitializeRow="ugrdWorkPreView_InitializeRow">
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:TemplatedColumn Key="selchk" Width="25px">
                                                                <HeaderTemplate>
                                                                    <img src="../images/checkbox.gif" alt="전제선택" style="cursor:pointer; vertical-align:middle;" onclick="selectChkBox('ugrdWorkPreView')" />
                                                                </HeaderTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <CellTemplate>
                                                                    <asp:checkbox id="cBox" runat="server" />
                                                                </CellTemplate>
                                                                <CellStyle VerticalAlign="Middle"></CellStyle>
                                                            </ig:TemplatedColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_TYPE_NAME" HeaderText="과제유형" Key="WORK_TYPE_NAME" AllowUpdate="No" Width="8%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="주관부서" Key="DEPT_NAME" AllowUpdate="No" Width="30%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_CODE" HeaderText="과제코드" Key="WORK_CODE" AllowUpdate="No" Width="8%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_NAME" HeaderText="과제명칭" Key="WORK_NAME" AllowUpdate="No" Width="30%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_EMP_NAME" HeaderText="관리자" Key="WORK_EMP_NAME" AllowUpdate="No" Width="10%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="COMPLETE_YN" HeaderText="완료여부" Key="COMPLETE_YN" AllowUpdate="No" Width="8%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_REF_ID" Key="WORK_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_REF_ID_ORG" Key="WORK_REF_ID_ORG" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_DEPT_REF_ID" Key="WORK_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_TYPE" Key="WORK_TYPE" Hidden="true"></ig:UltraGridColumn>
                                                        </Columns>
                                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                        </RowTemplateStyle>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                <DisplayLayout AllowColSizingDefault="Free"
                                                    AllowSortingDefault="No" 
                                                    AutoGenerateColumns="False" 
                                                    BorderCollapseDefault="Separate" 
                                                    CellPaddingDefault="2" 
                                                    CellClickActionDefault="RowSelect"
                                                    HeaderClickActionDefault="SortMulti"
                                                    Name="ugrdWorkPreView" 
                                                    RowHeightDefault="20px" 
                                                    RowSelectorsDefault="Yes"
                                                    SelectTypeRowDefault="Extended"
                                                    StationaryMargins="Header" 
                                                    TableLayout="Fixed" 
                                                    Version="4.00" 
                                                    ViewType="Flat" 
                                                    AllowUpdateDefault="Yes">
                                                    <GroupByBox Hidden="True">
                                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                    </GroupByBox>
                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                        <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                    </GroupByRowStyleDefault>
                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                    </FooterStyleDefault>
                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                        <Padding Left="3px" />
                                                    </RowStyleDefault>
                                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                    </SelectedRowStyleDefault>
                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                        ForeColor="White" HorizontalAlign="Left">
                                                        <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                    </HeaderStyleDefault>
                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                    </EditCellStyleDefault>
                                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="182px">
                                                    </FrameStyle>
                                                    <Pager>
                                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                        </PagerStyle>
                                                    </Pager>
                                                    <AddNewBox Hidden="False">
                                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                        </BoxStyle>
                                                    </AddNewBox>
                                                    <ActivationObject BorderColor="" BorderWidth="">
                                                    </ActivationObject>
                                                    <ClientSideEvents DblClickHandler="openWorkExecForm1" />
                                                </DisplayLayout>
                                            </ig:UltraWebGrid>
                                        </td>
                                    </tr>
                                    <tr style="height:30px;">
                                        <td style="vertical-align:middle;">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="padding-top: 10px;">
                                                        <img src="../images/icon/subtitle.gif" alt="" />&nbsp;<b>대상 과제 리스트</b>
                                                    </td>
                                                    <td align="right">
                                                        <asp:ImageButton ID="ibtnWorkAdd" runat="server" ImageUrl="../images/btn/btn_add_03.gif" OnClientClick="return alertWorkProc('INSERT');" OnClick="ibtnWorkAdd_Click" />&nbsp;
                                                        <asp:ImageButton ID="ibtnWorkDel" runat="server" ImageUrl="../images/btn/btn_add_04.gif" OnClientClick="return alertWorkProc('DELETE');" OnClick="ibtnWorkDel_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ig:UltraWebGrid ID="ugrdWorkAll" runat="server"  Width="100%" Height="182px" OnInitializeRow="ugrdWorkAll_InitializeRow">
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:TemplatedColumn Key="selchk" Width="25px">
                                                                <HeaderTemplate>
                                                                    <img src="../images/checkbox.gif" alt="전제선택" style="cursor:pointer; vertical-align:middle;" onclick="selectChkBox('ugrdWorkAll')" />
                                                                </HeaderTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <CellTemplate>
                                                                    <asp:checkbox id="cBox" runat="server" />
                                                                </CellTemplate>
                                                                <CellStyle VerticalAlign="Middle"></CellStyle>
                                                            </ig:TemplatedColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_TYPE_NAME" HeaderText="과제유형" Key="WORK_TYPE_NAME" AllowUpdate="No" Width="8%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="주관부서" Key="DEPT_NAME" AllowUpdate="No" Width="30%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_CODE" HeaderText="과제코드" Key="WORK_CODE" AllowUpdate="No" Width="8%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_NAME" HeaderText="과제명칭" Key="WORK_NAME" AllowUpdate="No" Width="30%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_EMP_NAME" HeaderText="관리자" Key="WORK_EMP_NAME" AllowUpdate="No" Width="10%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="COMPLETE_YN" HeaderText="완료여부" Key="COMPLETE_YN" AllowUpdate="No" Width="8%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_REF_ID" Key="WORK_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_REF_ID_ORG" Key="WORK_REF_ID_ORG" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_DEPT_REF_ID" Key="WORK_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_TYPE" Key="WORK_TYPE" Hidden="true"></ig:UltraGridColumn>
                                                        </Columns>
                                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                        </RowTemplateStyle>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                <DisplayLayout AllowColSizingDefault="Free"
                                                    AllowSortingDefault="No" 
                                                    AutoGenerateColumns="False" 
                                                    BorderCollapseDefault="Separate" 
                                                    CellPaddingDefault="2" 
                                                    CellClickActionDefault="RowSelect"
                                                    HeaderClickActionDefault="SortMulti"
                                                    Name="ugrdWorkAll" 
                                                    RowHeightDefault="20px" 
                                                    RowSelectorsDefault="Yes"
                                                    RowSelectorStyleDefault-Width="20px"
                                                    SelectTypeRowDefault="Extended"
                                                    StationaryMargins="Header" 
                                                    TableLayout="Fixed" 
                                                    Version="4.00" 
                                                    ViewType="Flat" 
                                                    AllowUpdateDefault="Yes">
                                                    <GroupByBox Hidden="True">
                                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                    </GroupByBox>
                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                        <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                    </GroupByRowStyleDefault>
                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                    </FooterStyleDefault>
                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                        <Padding Left="3px" />
                                                    </RowStyleDefault>
                                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                    </SelectedRowStyleDefault>
                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                        ForeColor="White" HorizontalAlign="Left">
                                                        <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                    </HeaderStyleDefault>
                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                    </EditCellStyleDefault>
                                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="182px">
                                                    </FrameStyle>
                                                    <Pager>
                                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                        </PagerStyle>
                                                    </Pager>
                                                    <AddNewBox Hidden="False">
                                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                        </BoxStyle>
                                                    </AddNewBox>
                                                    <ActivationObject BorderColor="" BorderWidth="">
                                                    </ActivationObject>
                                                    <ClientSideEvents DblClickHandler="openWorkExecForm2" />
                                                </DisplayLayout>
                                            </ig:UltraWebGrid>
                                        </td>
                                    </tr>
                                    <tr style="height:60px;">
                                        <td valign="top" style="height:60px; padding-top: 5px;">
	                                        <table cellpadding="0" cellspacing="0" border="0" class="tableBorder" width="100%">
	                                            <colgroup>
	                                                <col width="80px" />
	                                                <col width="100px" />
	                                                <col width="80px" />
	                                                <col width="100px" />
	                                                <col width="80px" />
	                                                <col width="80px" />
	                                            </colgroup>
	                                            <tr>
		                                            <td class="tabletitle2" align="center">과제유형</td>
		                                            <td class="tableContent" colspan="4" style="border-right: 0px;">
                                                        <asp:DropDownList ID="ddlWorkType" runat="server" Width="120px" CssClass="box01" ></asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="tableContent" style="border-left: 0px;">
                                                        <asp:ImageButton ID="iBtnSearch" runat="server" ImageUrl="../images/btn/b_033.gif" ImageAlign="AbsMiddle" OnClick="ibtnSearch_Click" />
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
		                                            <td class="tabletitle2" align="center">평가부서명</td>
		                                            <td class="tableContent">
		                                                <asp:TextBox ID="txtEstDeptNameF" runat="server" width="100%"></asp:TextBox>
                                                    </td>
                                                    <td class="tabletitle2" align="center">관리자 ID</td>
		                                            <td class="tableContent">
		                                                <asp:TextBox ID="txtEmpID" runat="server" width="100%"></asp:TextBox>
		                                            </td>
		                                            <td class="tabletitle2" align="center">관리자명</td>
		                                            <td class="tableContent">
		                                                <asp:TextBox ID="txtEmpName" runat="server" width="100%"></asp:TextBox>
		                                            </td>
	                                            </tr>
                                                <tr>
		                                            <td class="tabletitle2" align="center">과제코드</td>
		                                            <td class="tableContent">
		                                                <asp:TextBox ID="txtWorkCode" runat="server" width="100%"></asp:TextBox>
                                                    </td>
                                                    <td class="tabletitle2" align="center">과&nbsp;제&nbsp;명</td>
		                                            <td class="tableContent">
		                                                <asp:TextBox ID="txtWorkName" runat="server" width="100%"></asp:TextBox>
		                                            </td>
		                                            <td class="tabletitle2" align="center">완료여부</td>
		                                            <td class="tableContent">
		                                                <asp:DropDownList ID="ddlCompleteYN" runat="server" Width="100%" CssClass="box01"></asp:DropDownList>
		                                            </td>
	                                            </tr>
	                                        </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlWorkList" runat="server" Visible="false" Height="100%" Width="100%">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr style="height:25px;">
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <img src="../images/icon/subtitle.gif" alt="" />&nbsp;<b>관련 과제 리스트</b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="height: 450px;">
                                        <td>
                                            <ig:UltraWebGrid ID="ugrdWorkList" runat="server"  Width="100%" Height="100%" OnInitializeRow="ugrdWorkList_InitializeRow">
                                                <Bands>
                                                    <ig:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_TYPE_NAME" HeaderText="과제유형" Key="WORK_TYPE_NAME" AllowUpdate="No" Width="8%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="DEPT_NAME" HeaderText="주관부서" Key="DEPT_NAME" AllowUpdate="No" Width="30%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_CODE" HeaderText="과제코드" Key="WORK_CODE" AllowUpdate="No" Width="8%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_NAME" HeaderText="과제명칭" Key="WORK_NAME" AllowUpdate="No" Width="30%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_EMP_NAME" HeaderText="관리자" Key="WORK_EMP_NAME" AllowUpdate="No" Width="10%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="COMPLETE_YN" HeaderText="완료여부" Key="COMPLETE_YN" AllowUpdate="No" Width="8%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                            </ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_REF_ID" Key="WORK_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_REF_ID_ORG" Key="WORK_REF_ID_ORG" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_DEPT_REF_ID" Key="WORK_DEPT_REF_ID" Hidden="true"></ig:UltraGridColumn>
                                                            <ig:UltraGridColumn BaseColumnName="WORK_TYPE" Key="WORK_TYPE" Hidden="true"></ig:UltraGridColumn>
                                                        </Columns>
                                                        <RowTemplateStyle BackColor="White" BorderColor="White" BorderStyle="Ridge">
                                                            <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                                                        </RowTemplateStyle>
                                                    </ig:UltraGridBand>
                                                </Bands>
                                                <DisplayLayout AllowColSizingDefault="Free"
                                                    AllowSortingDefault="No" 
                                                    AutoGenerateColumns="False" 
                                                    BorderCollapseDefault="Separate" 
                                                    CellPaddingDefault="2" 
                                                    HeaderClickActionDefault="SortMulti"
                                                    Name="ugrdWorkList" 
                                                    RowHeightDefault="20px" 
                                                    RowSelectorsDefault="No" 
                                                    SelectTypeRowDefault="Extended"
                                                    StationaryMargins="Header" 
                                                    TableLayout="Fixed" 
                                                    Version="4.00" 
                                                    ViewType="Flat" 
                                                    AllowUpdateDefault="Yes">
                                                    <GroupByBox Hidden="True">
                                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
                                                    </GroupByBox>
                                                    <GroupByRowStyleDefault BackColor="#E7E7E7" BorderColor="#C7C7C7" ForeColor="DimGray">
                                                        <BorderDetails ColorLeft="199, 199, 199" ColorTop="199, 199, 199" />
                                                    </GroupByRowStyleDefault>
                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorTop="White" WidthTop="1px" />
                                                    </FooterStyleDefault>
                                                    <RowStyleDefault BackColor="#FCFEFE" BorderColor="#E5E5E5" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                        <Padding Left="3px" />
                                                    </RowStyleDefault>
                                                    <SelectedRowStyleDefault BackColor="#E2ECF4">
                                                    </SelectedRowStyleDefault>
                                                    <HeaderStyleDefault BackColor="#94BAC9" BorderColor="#E5E5E5" BorderStyle="Solid"
                                                        ForeColor="White" HorizontalAlign="Left">
                                                        <BorderDetails ColorLeft="148, 186, 201" ColorTop="148, 186, 201" />
                                                    </HeaderStyleDefault>
                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                    </EditCellStyleDefault>
                                                    <FrameStyle BackColor="Window" BorderColor="#E9EBEB" BorderStyle="Solid" BorderWidth="1px"
                                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%" Height="100%">
                                                    </FrameStyle>
                                                    <Pager>
                                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                        </PagerStyle>
                                                    </Pager>
                                                    <AddNewBox Hidden="False">
                                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
                                                        </BoxStyle>
                                                    </AddNewBox>
                                                    <ActivationObject BorderColor="" BorderWidth="">
                                                    </ActivationObject>
                                                    <ClientSideEvents DblClickHandler="openWorkExecForm3" />
                                                </DisplayLayout>
                                            </ig:UltraWebGrid>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Literal ID="ltrScript" runat="server" ></asp:Literal>
    </form>
</body>
</html>

