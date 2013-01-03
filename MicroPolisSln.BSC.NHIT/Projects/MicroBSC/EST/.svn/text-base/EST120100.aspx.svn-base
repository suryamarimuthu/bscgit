<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EST120100.aspx.cs" Inherits="EST_EST120100" %>

<%--<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>--%>
<%--<%@ Register TagPrefix="MenuControl" TagName="MenuControl" Src="~/_common/lib/MenuControl.ascx" %>--%>
<%Response.WriteFile("../_common/html/CommonTop.htm");%>

<script id="Infragistics" type="text/javascript">
    function setWeight() {
        var dept_type_ref_id = "<%=System.Web.HttpUtility.UrlEncode(DEPT_TYPE_REF_ID_LIST) %>";
        
    

        var comp_id = "<%=COMP_ID %>";
        var est_id = "<%=EST_ID %>";
        var estterm_ref_id = "<%=ESTTERM_REF_ID %>";
        var estterm_sub_id = "<%=ESTTERM_SUB_ID %>";
        var estterm_step_id = "<%=ESTTERM_STEP_ID %>";
        var pos_id = "<%=POS_ID %>";

        var popup_path = "EST120100M1.ASPX";

        var open_path = popup_path + "?"
                    + "COMP_ID=" + comp_id
                    + "&EST_ID=" + est_id
                    + "&ESTTERM_REF_ID=" + estterm_ref_id
                    + "&ESTTERM_SUB_ID=" + estterm_sub_id
                    + "&ESTTERM_STEP_ID=" + estterm_step_id
                    + "&DEPT_TYPE_REF_ID_LIST=" + dept_type_ref_id
                    + "&POS_ID=" + pos_id;


        var width = "480";
        var height = "640";
        
        
        var scroll = "no";
        gfOpenWindow(open_path
                    , width
                    , height
                    , scroll
                    , 'no'
                    , 'POP_UP_EST');

        return false;
    }

    function doApply() {
        if (confirm("개인점수로 반영하시겠습니까?")) {
            return true;
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
                            <asp:imagebutton id="iBtnSearch" onclick="iBtnSearch_Click" runat="server" imageurl="../images/btn/b_033.gif" imagealign="AbsMiddle"></asp:imagebutton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height:100%;">
            <td>
                <ig:UltraWebGrid ID="UltraWebGrid1" runat="server" Width="100%" Height="100%"
                    OnInitializeRow="UltraWebGrid1_InitializeRow"
                    OnInitializeLayout="UltraWebGrid1_InitializeLayout"
                    OnPageIndexChanged="UltraWebGrid1_PageIndexChanged">
                    <Bands>
                        <ig:UltraGridBand>
                            <Columns>
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
                                <ig:UltraGridColumn BaseColumnName="STATUS_IMG_PATH" Key="STATUS_IMG_PATH" HeaderText="STATUS_IMG_PATH" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="STATUS_IMG" Key="STATUS_IMG" HeaderText="상태" Width="40px" Hidden="true">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="ESTTERM_STEP_NAME" Key="ESTTERM_STEP_NAME" HeaderText="차수" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_EMP_ID" Key="TGT_EMP_ID" HeaderText="TGT_EMP_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_EMP_NAME" Key="TGT_EMP_NAME" HeaderText="피평가자" Width="120px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_CLS_ID" Key="TGT_POS_CLS_ID" HeaderText="TGT_POS_CLS_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_CLS_NAME" Key="TGT_POS_CLS_NAME" HeaderText="직급" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_DUT_ID" Key="TGT_POS_DUT_ID" HeaderText="TGT_POS_DUT_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_DUT_NAME" Key="TGT_POS_DUT_NAME" HeaderText="직책" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_GRP_ID" Key="TGT_POS_GRP_ID" HeaderText="TGT_POS_GRP_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_GRP_NAME" Key="TGT_POS_GRP_NAME" HeaderText="직군" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_RNK_ID" Key="TGT_POS_RNK_ID" HeaderText="TGT_POS_RNK_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_RNK_NAME" Key="TGT_POS_RNK_NAME" HeaderText="직위" Width="60px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_KND_ID" Key="TGT_POS_KND_ID" HeaderText="TGT_POS_KND_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_POS_KND_NAME" Key="TGT_POS_KND_NAME" HeaderText="TGT_POS_KND_NAME" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UP_DEPT_ID" Key="UP_DEPT_ID" HeaderText="UP_DEPT_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UP_DEPT_NAME" Key="UP_DEPT_NAME" HeaderText="본부" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UP_DEPT_POINT" Key="UP_DEPT_POINT" HeaderText="점수" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_DEPT_ID" Key="TGT_DEPT_ID" HeaderText="TGT_DEPT_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="TGT_DEPT_NAME" Key="TGT_DEPT_NAME" HeaderText="팀" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_POINT" Key="DEPT_POINT" HeaderText="점수" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UP_DEPT_WEIGHT" Key="UP_DEPT_WEIGHT" HeaderText="본부" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_WEIGHT" Key="DEPT_WEIGHT" HeaderText="팀" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="UP_DEPT_TYPE" Key="UP_DEPT_TYPE" HeaderText="UP_DEPT_TYPE" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="DEPT_TYPE" Key="DEPT_TYPE" HeaderText="DEPT_TYPE" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINT" Key="POINT" HeaderText="점수" Width="40px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="POINT_ORG" Key="POINT_ORG" HeaderText="POINT_ORG" Hidden="true">
                                </ig:UltraGridColumn>
                                
                                <ig:UltraGridColumn BaseColumnName="EST_DEPT_ID" Key="EST_DEPT_ID" HeaderText="EST_DEPT_ID" Hidden="true">
                                </ig:UltraGridColumn>
                                <ig:UltraGridColumn BaseColumnName="EST_EMP_ID" Key="EST_EMP_ID" HeaderText="EST_EMP_ID" Hidden="true">
                                </ig:UltraGridColumn>
                            </Columns>
                        </ig:UltraGridBand>
                    </Bands>
                    <DisplayLayout  RowHeightDefault="20px" 
                                    SelectTypeRowDefault="Extended"
                                    RowSelectorsDefault="No"
                                    CellClickActionDefault="RowSelect" 
                                    TableLayout="Fixed"
                                    StationaryMargins="Header" 
                                    AutoGenerateColumns="False"
                                    Name="UltraWebGrid1" 
                                    Version="4.00"
                                    Pager-AllowPaging="true"
                                    Pager-Alignment="Center"
                                    OptimizeCSSClassNamesOutput="False">
                        <GroupByBox>
                            <BoxStyle CssClass="GridGroupBoxStyle" />
                        </GroupByBox>
                        <RowStyleDefault CssClass="GridRowStyle" />
                        <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" />
                        <RowAlternateStyleDefault CssClass="GridRowAlternateStyle" />
                        <RowSelectorStyleDefault CssClass="GridRowSelectorStyle" />
                        <HeaderStyleDefault CssClass="GridHeaderStyle" />
                        <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand" />
                        <Images>
                            <CurrentRowImage Url="../images/icon/arrow_red_beveled.gif" />
                            <CurrentEditRowImage Url="../images/icon/arrow_red_beveled.gif" />
                        </Images>
                        <Pager PagerAppearance="Bottom" Alignment="Center" AllowPaging="true" StyleMode="PrevNext" PageSize="15" />
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
                            <asp:table id="tblViewStatus" runat="server" visible="false"></asp:table>
                            <asp:imagebutton id="iBtnSetWeight" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/b_085.gif" onclick="iBtnSetWeight_Click" onclientclick="return setWeight()"></asp:imagebutton>
                        </td>
                        <td style="text-align:right;">
                            <asp:imagebutton id="iBtnApplyWeight" runat="server" imagealign="AbsMiddle" imageurl="../images/btn/btn_score.gif" onclick="iBtnApplyWeight_Click" onclientclick="return doApply()"></asp:imagebutton>
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