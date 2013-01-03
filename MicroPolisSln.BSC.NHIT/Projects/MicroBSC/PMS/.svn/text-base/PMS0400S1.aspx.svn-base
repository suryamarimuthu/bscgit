<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMS0400S1.aspx.cs" Inherits="PMS_PMS0400S1" %>
<%@ Register Src="../_common/lib/MenuControl_Bottom.ascx" TagName="MenuControl_Bottom" TagPrefix="MenuControl" %>
<%Response.WriteFile( "../_common/html/CommonTop.htm" );%>

<script type="text/javascript">
    var param1 = false;
    function selectChkBox(chkChild) {
        var _elements = document.forms[0].elements;

        for (var i = 0; i < _elements.length; i++) {
            if (_elements[i].id.indexOf(chkChild) >= 0 && _elements[i].type == "checkbox") {
                if (param1) {
                    _elements[i].checked = false;
                }
                else {
                    _elements[i].checked = true;
                }
            }
        }

        param1 = (param1 == true) ? false : true;
    }
</script>

<form id="form1" runat="server">
<div>
<asp:placeholder runat="server" ID="phdLayout"></asp:placeholder>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td>
                <table class="tableBorder" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="cssTblTitle" style="width:20%;" >평가기간</td> 
                        <td class="cssTblContent" style="width:80%;"> 
                            <asp:dropdownlist id="ddlEstTermRefID" runat="server" class="box01" OnSelectedIndexChanged="ddlEstTermRefID_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>
                            <asp:dropdownlist id="ddlEstTermSubID" runat="server" class="box01" OnSelectedIndexChanged="ddlEstTermSubID_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>
                        </td> 
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="cssPopBtnLine">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                    <tr>
                        <td style="width:29%;">
                            <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                    <td ><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Text="프로젝트 목록"/>(<img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                                        <asp:label id="lblRowCount" runat="server" text="0"></asp:label>
                                        <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />)</td>
                                   
                                </tr>
                            </table>
                                
                        </td>
                        <td style="width:1%;">
                        </td>
                        <td style="width:70%;" align="right">
                            <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                <tr>
                                    <td style="width:50%;">
                                        <table  cellpadding="0" cellspacing="1" border="0" style="height:98%; width:100%;">
                                            <tr>
                                                <td style="width:1%;"><img src= "../images/title/ma_t14.gif" alt="" /></td>
                                                <td><asp:Label ID="lblTitle2" runat="server" Font-Bold="true" Text="수행인력"/>(<img style="vertical-align: middle;"src="../Images/etc/lis_t01.gif" alt="" />
                                                    <asp:label id="lblRowCount2" runat="server" text="0"></asp:label>
                                                    <img style="vertical-align: middle;" src="../Images/etc/lis_t02.gif" alt="" />)</td>
                                               
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width:50%;" align="right">
                                        <asp:ImageButton ID="iBtnSearch" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/btn/b_033.gif" onclick="iBtnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        <tr style="height:100%;">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                    <tr>
                        <td style="width:29%;">
                            <ig:UltraWebGrid    id="UltraWebGrid1" runat="server"
                                                Width="100%" Height="100%" 
                                                oninitializerow="UltraWebGrid1_InitializeRow"
                                                OnSelectedRowsChange="UltraWebGrid1_SelectedRowsChange">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:ultragridcolumn basecolumnname="PRJ_REF_ID" key="PRJ_REF_ID" hidden="True">
                                                <header caption="PRJ_REF_ID" />
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="PRJ_CODE" key="PRJ_CODE" hidden="True">
                                                <header caption="PRJ_CODE" />
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="EST_DEPT_ID" key="EST_DEPT_ID" hidden="True">
                                                <header caption="EST_DEPT_ID" />
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="EST_EMP_ID" key="EST_EMP_ID" hidden="True">
                                                <header caption="EST_EMP_ID" />
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="PRJ_NAME" key="PRJ_NAME" Width="200px">
                                                <header caption="프로젝트명" />
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <cellstyle horizontalalign="Left"></cellstyle>
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="EST_DEPT_NAME" key="EST_DEPT_NAME" Width="200px">
                                                <header caption="수행부서명" />
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <cellstyle horizontalalign="Left"></cellstyle>
                                            </ig:ultragridcolumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                
                                <DisplayLayout  AllowColSizingDefault="Free" 
                                                BorderCollapseDefault="Separate" 
                                                HeaderClickActionDefault="SortMulti" 
                                                RowHeightDefault="20px" 
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="Extended" 
                                                TableLayout="Fixed" 
                                                StationaryMargins="Header" 
                                                OptimizeCSSClassNamesOutput="False"
                                                CellClickActionDefault="RowSelect"
                                                AutoGenerateColumns="False" >
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                        <td style="width:1%;">
                        </td>
                        <td style="width:70%;" align="right">
                            <ig:UltraWebGrid    id="UltraWebGrid2" runat="server"
                                                Width="100%" Height="100%"
                                                OnInitializeRow="UltraWebGrid2_InitializeRow">
                                <Bands>
                                    <ig:UltraGridBand>
                                        <Columns>
                                            <ig:ultragridcolumn basecolumnname="PRJ_REF_ID" key="PRJ_REF_ID" hidden="True" >
                                                <header caption="PRJ_REF_ID" />
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="PRJ_CODE" key="PRJ_CODE" hidden="True" >
                                                <header caption="PRJ_CODE" />
                                            </ig:ultragridcolumn>
                                            
                                            <ig:ultragridcolumn basecolumnname="TGT_DEPT_ID" key="TGT_DEPT_ID" Hidden="true">
                                                <header caption="TGT_DEPT_ID" />
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="TGT_DEPT_NAME" key="TGT_DEPT_NAME" Width="30%">
                                                <header caption="피평가부서" />
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <cellstyle horizontalalign="Left"></cellstyle>
                                            </ig:ultragridcolumn>
                                            
                                            <ig:ultragridcolumn basecolumnname="TGT_EMP_ID" key="TGT_EMP_ID" Hidden="true">
                                                <header caption="TGT_EMP_ID" />
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="TGT_EMP_NAME" key="TGT_EMP_NAME" Width="30%">
                                                <header caption="피평가자" />
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <cellstyle horizontalalign="Left"></cellstyle>
                                            </ig:ultragridcolumn>                                            
                                            
                                            <ig:ultragridcolumn basecolumnname="POS_CLS_ID" key="POS_CLS_ID" Width="40px" Hidden="true">
                                                <header caption="POS_CLS_ID" />
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="POS_CLS_NAME" key="POS_CLS_NAME" Width="40px" Hidden="true">
                                                <header caption="직급" />
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <cellstyle horizontalalign="Center"></cellstyle>
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="POS_CLS_ID" key="POS_CLS_ID" Width="40px" Hidden="true">
                                                <header caption="POS_CLS_ID" />
                                            </ig:ultragridcolumn>                                            
                                            <ig:ultragridcolumn basecolumnname="POS_CLS_NAME" key="POS_CLS_NAME" Width="40px" Hidden="true">
                                                <header caption="직명" />
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <cellstyle horizontalalign="Center"></cellstyle>
                                            </ig:ultragridcolumn>                                            
                                            <ig:ultragridcolumn basecolumnname="POS_GRP_ID" key="POS_GRP_ID" Width="40px" Hidden="true">
                                                <header caption="POS_GRP_ID" />
                                            </ig:ultragridcolumn>                                            
                                            <ig:ultragridcolumn basecolumnname="POS_GRP_NAME" key="POS_GRP_NAME" Width="40px" Hidden="true">
                                                <header caption="직군" />
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <cellstyle horizontalalign="Center"></cellstyle>
                                            </ig:ultragridcolumn>                                            
                                            <ig:ultragridcolumn basecolumnname="POS_RNK_ID" key="POS_RNK_ID" Width="40px" Hidden="true">
                                                <header caption="POS_RNK_ID" />
                                            </ig:ultragridcolumn>                                            
                                            <ig:ultragridcolumn basecolumnname="POS_RNK_NAME" key="POS_RNK_NAME" Width="40px" Hidden="true">
                                                <header caption="직위" />
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <cellstyle horizontalalign="Center"></cellstyle>
                                            </ig:ultragridcolumn>                                            
                                            
                                            <ig:ultragridcolumn basecolumnname="PRJ_POINT" key="PRJ_POINT" Width="60px">
                                                <header caption="프로젝트" />
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <cellstyle horizontalalign="Right"></cellstyle>
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="POINT" key="POINT" Width="50px">
                                                <header caption="기여도" />
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <cellstyle horizontalalign="Right"></cellstyle>
                                            </ig:ultragridcolumn>
                                            <ig:ultragridcolumn basecolumnname="EST_POINT" key="EST_POINT" Width="60px">
                                                <header caption="종합평가" />
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <cellstyle horizontalalign="Right"></cellstyle>
                                            </ig:ultragridcolumn>
                                        </Columns>
                                    </ig:UltraGridBand>
                                </Bands>
                                
                                <DisplayLayout  AllowColSizingDefault="Free" 
                                                BorderCollapseDefault="Separate" 
                                                HeaderClickActionDefault="SortMulti" 
                                                RowHeightDefault="20px" 
                                                RowSelectorsDefault="No" 
                                                SelectTypeRowDefault="Extended" 
                                                TableLayout="Fixed" 
                                                StationaryMargins="Header" 
                                                OptimizeCSSClassNamesOutput="False"
                                                ReadOnly="LevelTwo"
                                                AutoGenerateColumns="False" >
                                    <RowStyleDefault  CssClass="GridRowStyle" />
                                    <SelectedRowStyleDefault CssClass="GridSelectedRowStyle" ></SelectedRowStyleDefault>
                                    <RowAlternateStyleDefault CssClass="GridRowAlternateStyle"></RowAlternateStyleDefault>                                    
                                    <RowSelectorStyleDefault  CssClass="GridRowSelectorStyle" />
                                    <HeaderStyleDefault CssClass="GridHeaderStyle" ></HeaderStyleDefault>                                   
                                    <FrameStyle CssClass="GridFrameStyle" Width="100%" Height="100%" Cursor="Hand"></FrameStyle>
                                </DisplayLayout>
                            </ig:UltraWebGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        
        <tr class="cssPopBtnLine">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                    <tr>
                        <td align="right" style="width:29%;">
                            <asp:ImageButton id="ibnCalcEmpEstPoint" runat="server" imageurl="../images/btn/btn_score.gif" imagealign="absmiddle" onclick="ibnCalcEmpEstPoint_Click" />
                        </td>
                        <td style="width:1%;"></td>
                        <td align="right" style="width:70%;">
                            <table border="0" cellpadding="0" cellspacing="0"  style="height:100%;">
                                <tr>
                                    
                                    <td style="width:20px;" align="center"><img src="../images/icon/color/red.gif" /></td>
                                    <td style="width:40px;">미평가</td>
                                    <td style="width:20px;" align="center"><img src="../images/icon/color/green.gif" /></td>
                                    <td style="width:40px;">평가중</td>
                                    <td style="width:20px;" align="center"><img src="../images/icon/color/blue.gif" /></td>
                                    <td>평가완료</td>
                                </tr>
                            </table>                            
                            <%--<asp:Button id="ibnConfirm" runat="Server" text="확정" onclick="ibnConfirm_Click" />
                            <asp:Button id="ibnTotalView" runat="Server" text="전체보기" onclick="ibnTotalView_Click" />
                            <asp:imagebutton id="ibnDownExcel" runat="server" imagealign="AbsMiddle" imageurl="~/images/btn/b_041.gif" onclick="ibnDownExcel_Click" Visible="false"></asp:imagebutton>                        
                            <ig:UltraWebGridExcelExporter ID="uGridExcelExporter" runat="server"></ig:UltraWebGridExcelExporter>--%>
                            
                            <asp:literal id="ltrScript" runat="server"></asp:literal>
                            <asp:label id="lblCompTitle" runat="server" visible="false" />
                            <asp:dropdownlist id="ddlCompID" runat="server" class="box01" autopostback="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
<asp:placeholder runat="server" ID="phdBottom"></asp:placeholder>
</div>
</form>
<%Response.WriteFile( "../_common/html/CommonBottom.htm" );%>