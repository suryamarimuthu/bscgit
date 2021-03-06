﻿<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeFile="EST110500.aspx.cs" Inherits="EST_EST110500" %>

<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>

<script id="Infragistics" type="text/javascript">
    function DblClickHandler(gridName, id) {
        var cell = igtbl_getElementById(id);
        var row = igtbl_getRowById(id);

        var comp_id = row.getCellFromKey("COMP_ID").getValue();
        var est_id = row.getCellFromKey("EST_ID").getValue();
        var estterm_ref_id = row.getCellFromKey("ESTTERM_REF_ID").getValue();
        var estterm_sub_id = row.getCellFromKey("ESTTERM_SUB_ID").getValue();
        var estterm_step_id = row.getCellFromKey("ESTTERM_STEP_ID").getValue();
        var est_dept_id = row.getCellFromKey("EST_DEPT_ID").getValue();
        var est_emp_id = row.getCellFromKey("EST_EMP_ID").getValue();
        var tgt_dept_id = row.getCellFromKey("TGT_DEPT_ID").getValue();
        var tgt_emp_id = row.getCellFromKey("TGT_EMP_ID").getValue();
        var status_id = row.getCellFromKey("STATUS_ID").getValue();
        var est_tgt_type = "<%=EST_TGT_TYPE %>";

        var popup_path = row.getCellFromKey("POPUP_PATH").getValue();

        if (estterm_step_id == 2 && est_tgt_type == 'EST') {
            if (status_id == 'N' ) {
                alert("자기 평가 미실행되었습니다. 1차 평가 불가능");
                return false;
            }
            if (status_id == 'O' ) {
               alert("자기 평가 중입니다. 1차 평가 불가능");
               return false;
            }

        }
        //2차평가에서 1차평가 정보 보기
        if (estterm_step_id == 3) {
            estterm_step_id = 2;
            est_dept_id = row.getCellFromKey("EST_DEPT_ID_1ST").getValue();
            est_emp_id = row.getCellFromKey("EST_EMP_ID_1ST").getValue();
            status_id = row.getCellFromKey("STATUS_ID_1ST").getValue();
        }
        

        var open_path = popup_path + "?"
                    + "COMP_ID=" + comp_id
                    + "&EST_ID=" + est_id
                    + "&ESTTERM_REF_ID=" + estterm_ref_id
                    + "&ESTTERM_SUB_ID=" + estterm_sub_id
                    + "&ESTTERM_STEP_ID=" + estterm_step_id
                    + "&EST_DEPT_ID=" + est_dept_id
                    + "&EST_EMP_ID=" + est_emp_id
                    + "&TGT_DEPT_ID=" + tgt_dept_id
                    + "&TGT_EMP_ID=" + tgt_emp_id
                    + "&STATUS_ID=" + status_id
                    + "&EST_TGT_TYPE=" + est_tgt_type


        var width = "1230";
        var height = "700";
        if (est_tgt_type == "EST") {
            width = "840";
            height = "500";
        }
        
        
        var scroll = "no";
        gfOpenWindow(open_path
                    , width
                    , height
                    , scroll
                    , 'no'
                    , 'POP_UP_EST');    
    }


    function doConfirm() {
        if (doChecking('UltraWebGrid1')) {
            if (confirm("선택된 데이터를 확정 하시겠습니까?")) {
                return true;
            }
        }

        return false;
    }

    function doCancel() {
        if (doChecking('UltraWebGrid1')) {
            if (confirm("선택된 데이터를 확정 취소 하시겠습니까?")) {
                return true;
            }
        }

        return false;
    }
</script>

<form id="form2" runat="server">
<div>
    <%--<MenuControl:MenuControl ID="MenuControl1" runat="server" />--%>
    <asp:placeholder runat="server" id="phdLayout"></asp:placeholder>
    <!--- MAIN START --->
    <table cellpadding="0" cellspacing="0" border="0" height="100%" width="100%">
        <tr>
            <td>
                <table class="tableBorder" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="cssTblTitle" style="width: 15%;">
                            평가기간
                        </td>
                        <td class="cssTblContent" style="width: 85%;">
                            <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01"></asp:dropdownlist>
                            <asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01"></asp:dropdownlist>
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01"></asp:dropdownlist>
                            <asp:label id="lblCompTitle" runat="server"></asp:label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="cssPopBtnLine">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <img align="absmiddle" src="../Images/etc/lis_t01.gif" />
                            <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                            <img align="absmiddle" src="../Images/etc/lis_t02.gif" />
                        </td>
                        <td>
                            <asp:Label id="lblNotice" runat="server" visible="false"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:DropDownList id="ddlBIAS_TYPE" runat="server" cssclass="box01" visible="false">
                                <asp:ListItem runat="server" value="ORG">원시점수</asp:ListItem>
                                <asp:ListItem runat="server" value="AVG">평균조정</asp:ListItem>
                                <asp:ListItem runat="server" value="STD">표준편차</asp:ListItem>
                            </asp:DropDownList>
                            <asp:imagebutton id="iBtnBias" onclick="iBtnBias_Click" runat="server" imageurl="../images/btn/b_186.gif" imagealign="AbsMiddle" visible="false"></asp:imagebutton>
                            <asp:imagebutton id="iBtnSearch" onclick="iBtnSearch_Click" runat="server" imageurl="../images/btn/b_033.gif" imagealign="AbsMiddle"></asp:imagebutton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:100%;">
            <td>
                <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%" OnInitializeRow="UltraWebGrid1_InitializeRow"
                    OnInitializeLayout="UltraWebGrid1_InitializeLayout">
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
                                <ig:TemplatedColumn Key="selchk" Width="30px" AllowGroupBy="No" AllowResize="Fixed" AllowUpdate="No">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" />
                                    <CellTemplate>
                                        <asp:checkbox id="cBox" runat="server" style="cursor: pointer" />
                                    </CellTemplate>
                                    <HeaderTemplate>
                                        <asp:checkbox id="cBox_header" runat="server" style="cursor: pointer" onclick="selectChkBox(this, 'UltraWebGrid1');" />
                                    </HeaderTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="COMP_ID" Key="COMP_ID" HeaderText="COMP_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_ID" Key="EST_ID" HeaderText="EST_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_REF_ID" Key="ESTTERM_REF_ID" HeaderText="ESTTERM_REF_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_SUB_ID" Key="ESTTERM_SUB_ID" HeaderText="ESTTERM_SUB_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_ID" Key="ESTTERM_STEP_ID" HeaderText="ESTTERM_STEP_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STATUS_ID" Key="STATUS_ID" HeaderText="STATUS_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STATUS_ID_1ST" Key="STATUS_ID_1ST" HeaderText="STATUS_ID_1ST" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STATUS_ID_2ND" Key="STATUS_ID_2ND" HeaderText="STATUS_ID_2ND" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STATUS_IMG_PATH" Key="STATUS_IMG_PATH" HeaderText="STATUS_IMG_PATH" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STATUS_IMG" Key="STATUS_IMG" HeaderText="평가상태" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_NAME" Key="ESTTERM_STEP_NAME" HeaderText="차수" Width="40px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_ID" Key="EST_DEPT_ID" HeaderText="EST_DEPT_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Key="EST_EMP_ID" HeaderText="EST_EMP_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_ID_1ST" Key="EST_DEPT_ID_1ST" HeaderText="EST_DEPT_ID_1ST" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_EMP_ID_1ST" Key="EST_EMP_ID_1ST" HeaderText="EST_EMP_ID_1ST" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_DEPT_ID" Key="TGT_DEPT_ID" HeaderText="TGT_DEPT_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_EMP_NAME" Key="TGT_EMP_NAME" HeaderText="피평가자" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign = "Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_DEPT_NAME" Key="TGT_DEPT_NAME" HeaderText="소속부서" Width="150px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_EMP_ID" Key="TGT_EMP_ID" HeaderText="TGT_EMP_ID" Hidden="true">
                                </ig:UltraGridColumn>
                               
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_CLS_NAME" Key="TGT_POS_CLS_NAME" HeaderText="직급" Width="60px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_DUT_NAME" Key="TGT_POS_DUT_NAME" HeaderText="직책" Width="60px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_GRP_NAME" Key="TGT_POS_GRP_NAME" HeaderText="직군" Width="60px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_RNK_NAME" Key="TGT_POS_RNK_NAME" HeaderText="직위" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="Q_SBJ_POINT_AVG" Key="Q_SBJ_POINT_AVG" HeaderText="전체평균" Width="60px" hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINT_ORG" Key="POINT_ORG" HeaderText="평가점수" Width="60px" hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINT_AVG" Key="POINT_AVG" HeaderText="평균 조정점수" Width="100px" hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINT_STD" Key="POINT_STD" HeaderText="표준편차 조정점수" Width="120px" hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINT_ORG_1ST" Key="POINT_ORG_1ST" HeaderText="1차평가 원시점수" Width="120px" hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINT_CTRL_ORG_1ST" Key="POINT_CTRL_ORG_1ST" HeaderText="1차평가 조정점수" Width="120px" hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:TemplatedColumn BaseColumnName="POINT_BALANCE" Key="POINT_BALANCE" HeaderText="2차 평가점수" Width="100px" hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" />
                                    <CellTemplate>
                                        <ig:WebNumericEdit ID="POINT_BALANCE" runat="server" DataMode="Double" MaxValue="1.0" MinValue="-1.0" NullText="0" Width="90px"></ig:WebNumericEdit>
                                    </CellTemplate>
                                </ig:TemplatedColumn>
                                <ig:UltraGridColumn BaseColumnName="POINT_CTRL_ORG" Key="POINT_CTRL_ORG" HeaderText="조정점수" Width="60px" hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINT" Key="POINT" HeaderText="환산점수" Width="60px" hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POPUP_PATH" Key="POPUP_PATH" HeaderText="POPUP_PATH" Hidden="true">
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout CellPaddingDefault="2"
                            AllowColSizingDefault="Free"
                            AllowColumnMovingDefault="OnServer"
                            AllowDeleteDefault="No"
                            AllowSortingDefault="No"
                            BorderCollapseDefault="Separate"
                            Name="UltraWebGrid1"
                            RowHeightDefault="20px"
                            RowSelectorsDefault="No"
                            SelectTypeRowDefault = "Extended"
                            CellClickActionDefault = "NotSet"  
                            Version="4.00"
                            TableLayout="Fixed" 
                            StationaryMargins="No"
                            AutoGenerateColumns="False"
                            OptimizeCSSClassNamesOutput="False">
                        <GroupByBox>
                            <BoxStyle CssClass="GridGroupBoxStyle" />
                        </GroupByBox>
                        <RowStyleDefault CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" />
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle" />
                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" />
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%"  Cursor="Hand" />
                        <Images>
                            <CurrentRowImage Url="../images/icon/arrow_red_beveled.gif" />
                            <CurrentEditRowImage Url="../images/icon/arrow_red_beveled.gif" />
                        </Images>
                        <ClientSideEvents DblClickHandler="DblClickHandler"/>
                    </DisplayLayout>
                </ig:UltraWebGrid>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" height="100%">
                    <tr>
                        <td>
                            <asp:table id="tblViewStatus" runat="server"></asp:table>
                        </td>
                        <td style="text-align:right;">
                            <asp:imagebutton id="iBtnSearchAll" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_165.gif" onclick="iBtnSearchAll_Click" Visible="false"></asp:imagebutton>
                            
                            <asp:imagebutton id="iBtnConfirm_SelfEst" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_015.gif" onclick="iBtnConfirm_SelfEst_Click" onclientclick="return doConfirm()" Visible="false"></asp:imagebutton>                            
                            <asp:imagebutton id="iBtnCancel_SelfEst" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_178.gif" onclick="iBtnCancel_SelfEst_Click" onclientclick="return doCancel()" Visible="false"></asp:imagebutton>
                            
                            <asp:imagebutton id="iBtnSave_EstQ" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_167.gif" onclick="iBtnSave_EstQ_Click" Visible="false"></asp:imagebutton>
                            <asp:imagebutton id="iBtnConfirm_EstQ" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_163.gif" onclick="iBtnConfirm_EstQ_Click" onclientclick="return doConfirm()" Visible="false"></asp:imagebutton>
                            <asp:imagebutton id="iBtnCancel_EstQ" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_178.gif" onclick="iBtnCancel_EstQ_Click" onclientclick="return doCancel()" Visible="false"></asp:imagebutton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server">
    </ig:UltraWebGridExcelExporter>
    <asp:literal id="ltrScript" runat="server"></asp:literal>
    <asp:linkbutton id="lbnReload" runat="server" onclick="lbnReload_Click"></asp:linkbutton>
    <!--- MAIN END --->
    <asp:placeholder runat="server" id="phdBottom"></asp:placeholder>
</div>
</form>
<%Response.WriteFile("../_common/html/CommonBottom.htm");%>